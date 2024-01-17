const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken')

const secretKey = require('crypto').randomBytes(64).toString('hex')

async function createNewJWT(userId)
{
    let token = jwt.sign({userId: userId}, secretKey, {expiresIn: "30m"});
    return token;
}

const authenticateJWT = async (req, res, next) => {
    const token = req.header('Authorization').split(' ')[1];


    if (!token) {
        return res.status(401).json({ message: 'Unauthorized' });
    }

    jwt.verify(token, secretKey, (err, user) => {
        if (err) {
            return res.status(403).json({ message: 'Forbidden; JWT False.' });
        }

        req.user = user;
        next();
    });
};

function parseJwt (token) {
    return JSON.parse(Buffer.from(token.split('.')[1], 'base64').toString());
}

async function createNewHH(db, userName, hash, res){
    db.query(`CALL CreateNewHH('${userName}', '${hash}');`, (err, result, fields) => {
        if (err) {
            res.status(409).json({message: 'User already exists!'}); // code 409: user already exists.
            return;
        }
        res.status(200).json({message: 'User successfully created.'}); // code 200: user has been created.
    });
};

async function attemptLogin(db, userName, password, res)
{
    let validData = false;
    db.query(`SELECT * FROM HOUSEHOLDS hh WHERE hh.userName = '${userName}';`, async (err, result, fields) => { // Was geht hier ab bitte
        if (result.length > 0) {
            let r = bcrypt.compareSync(password, result[0].hashedPassword);
            if (r) {
                validData = true;
                let userId = result[0].hId;
                let t = await createNewJWT(userId)
                res.status(200).json({message: "SUCCESSFUL LOGIN!", jwtToken: t});
                // TODO: Daten zurück senden
            }
        }

        if (validData)
            return;

        res.status(401).json({message: "ERROR; USERNAME OR PASSWORD FALSE."});

    });
}

async function CreateNewStorage(db, containerName, hId, sUnits, res)
{ // TODO: SUnits erstellen irgendwie canceerr
    let cId;

    db.query(`CALL CreateNewStorage('${containerName}', ${hId})`, (err, result) => {
        if (err)
        {
            console.log(err)
            res.status(500).json({message: "ERROR; DATABASE HAS FAILED."});
            return;
        }

        let cId = result[0][0].nextId;

        for (const unit of sUnits) {
            db.query(`CALL CreateNewSUnit(${cId}, '${unit.xCord}', '${unit.yCord}')`); // Schlechte practices, vllt 2 Funktionen in 1?
        }
        res.status(200).json({message: "SUCCESSFUL CREATION OF STORAGE!"})
    })
}

//async function CreateNewSUnit(db, )

module.exports = {createNewHH, attemptLogin, authenticateJWT, parseJwt, CreateNewStorage}