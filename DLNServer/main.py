import os
import numpy as np
import tensorflow as tf
from PIL import Image
from flask import Flask, request, jsonify

app = Flask(__name__)

# Load the pre-trained model
model_path = r"C:\Users\dustin\Desktop\augmentedV1.h5"
loaded_model = tf.keras.models.load_model(model_path)

# Define class labels
class_labels = ["apple", "blueberry", "milk", "orange", "pear"]


@app.route('/predict', methods=['POST'])
def predict():
    try:
        # Get the uploaded image file
        image_file = request.files['image']

        # Ensure the file is an image
        if image_file and allowed_file(image_file.filename):
            # Read and preprocess the image
            img = Image.open(image_file)
            img = img.resize((256, 256))  # Resize the image to the desired size
            img = np.array(img) / 255.0  # Normalize the image to [0, 1]
            img = np.expand_dims(img, axis=0)

            # Predict the class label
            predictions = loaded_model.predict(img)
            predicted_class = np.argmax(predictions, axis=1)
            predicted_label = class_labels[predicted_class[0]]

            return jsonify({'predicted_label': predicted_label})

        else:
            return jsonify({'error': 'Invalid file format. Please upload an image.'})
    except Exception as e:
        return jsonify({'error': 'An error occurred: {}'.format(str(e))})


def allowed_file(filename):
    return '.' in filename and filename.rsplit('.', 1)[1].lower() in {'jpg', 'jpeg', 'png'}


if __name__ == '__main__':
    app.run(debug=True)
