import os
os.environ['TF_CPP_MIN_LOG_LEVEL'] = '2'
from PIL import Image

import io
import tensorflow as tf
from tensorflow import keras
import numpy as np

from flask import Flask, request, jsonify

loaded_model = tf.keras.models.load_model("augmentedV1.h5")

def preprocess_image(image):
    img = image
    img = img.resize((256, 256))  # Resize the image to 256x256
    img = img.convert("RGB")      # Ensure it has 3 color channels (RGB)
    img = np.array(img) / 255.0   # Normalize the image to [0, 1]
    img = np.expand_dims(img, axis=0)
    return img

def predict(img):
    predictions = loaded_model.predict(img)

    predicted_class = np.argmax(predictions, axis=1)

    class_labels = ["apple", "blueberry", "milk", "orange", "pear"]
    predicted_label = class_labels[predicted_class[0]]
    return predicted_label


app = Flask(__name__)

@app.route("/", methods=["GET", "POST"])
def index():
    if request.method == "POST":
        file = request.files.get('file')
        if file is None or file.filename == "":
            return jsonify({"error": "no file"})

        try:
            image_bytes = file.read()
            img = Image.open(io.BytesIO(image_bytes))
            tensor = preprocess_image(img)
            prediction = predict(tensor)
            data = {"prediction": prediction}
            return jsonify(data)

        except Exception as e:
            return jsonify({"error": str(e)})
    return "OK"


if __name__ == "__main__":
    app.run(debug=True)
