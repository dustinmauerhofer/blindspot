const express = require('express');
const app = express();
const mysql = require('mysql');
const bcrypt = require('bcrypt');
const methods = require('./methods.js');
const connection = mysql.createConnection({
   host: 'localhost',
   user: 'root',
   password: 'dbpass',
   database: 'Blindspot'
})

const secretKey = 'xSecretx123';

connection.connect((err) => {
   if (err)
      throw err;

   console.log('Connection to the Database has been established.')
});

app.use(express.json());

const port = 3000;
app.listen(port, () => {
   console.log("server has started")
});

app.get("/users", async (req, res) => {
   let x = [];
   connection.query('SELECT * FROM HOUSEHOLDS;', (err, result, fields) => {
      if (err) throw err;

      for (const v of result) {
         x.push(v.hId);
      }

      res.json(x);
   });

});

app.post("/users/register", async (req, res) => { // 409 code bei gitbs schon sonst 200
   //res.send('Post data has been received; Storage: ' + req.body.storage + '; Location: ' + req.body.location + '; Produkt: ' +  req.body.produkt);
   let userName = req.body.userName;
   let password = req.body.password;

   bcrypt.hash(password, 5, (err, hash) => {
      methods.createNewHH(connection, userName, hash, res);
   });
});

app.post("/users/login", async (req, res) => { // 401 code bei falsche daten sonst 200
   let userName = req.body.userName;
   let password = req.body.password;
   await methods.attemptLogin(connection, userName, password, res);
});

app.post("/containers/create", methods.authenticateJWT, async (req, res) => { //Überlegung JWT bei Erstellung von Storages?
   const token = req.header('Authorization').split(' ')[1];
   let userId = methods.parseJwt(token).userId

   let stName = req.body.storageName;
   let stUnits = req.body.storageUnits;

   await methods.CreateNewStorage(connection, stName, userId, stUnits, res);
})

app.post("/products/create", methods.authenticateJWT, async (req, res) => {
   let suId = req.body.storageUnitId;
   let pName = req.body.productName;
   let lrAlignment = req.body.lrAlignment;
   let fbAlignment = req.body.fbAlignment;

   connection.query(`INSERT INTO Products VALUES(${suId}, '${pName}', ${lrAlignment}, ${fbAlignment});`, (err, result) => {
      if (err)
      {
         console.log(err);
         res.status(500).json({message:'Database could not add new value.'})
         return;
      }

      res.status(200).json({message:'Successfully added new product: ' + pName});
   });
})

app.get("/products/search", methods.authenticateJWT, async (req, res) => {
   const token = req.header('Authorization').split(' ')[1];
   let userId = methods.parseJwt(token).userId;
   let productName = req.query.productName;
   console.log(productName)

   connection.query(`SELECT c.cId, su.suId, su.xCord, su.yCord, p.left_right_alignment, p.front_back_alignment 
                    FROM Products p 
                    INNER JOIN SUnit su ON p.suId = su.suId 
                    INNER JOIN Container c ON c.cId = su.cid
                    WHERE ${userId} = c.hId and p.pName = '${productName}';`, (err, result) => {

      if (result) console.log(result);
      else console.log(err);
   });

})