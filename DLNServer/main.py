import io
import os
import numpy as np
import tensorflow as tf
from PIL import Image
from flask import Flask, request, jsonify

app = Flask(__name__)

# Load the pre-trained model
model_path = r"augmentedV1.h5"
loaded_model = tf.keras.models.load_model(model_path)

# Define class labels
class_labels = ["apple", "blueberry", "milk", "orange", "pear"]


@app.route('/predict', methods=['GET','POST'])
def predict():
       try:
            image_bytes = request.get_data()

            if not image_bytes:
                return jsonify({"error": "no data"})

            pillow_img = Image.open(io.BytesIO(image_bytes)).convert('L')

            # Read and preprocess the image
            img = pillow_img.convert('RGB')  # Convert to RGB mode
            img = img.resize((256, 256))  # Resize the image to the desired size
            img = np.array(img) / 255.0  # Normalize the image to [0, 1]
            img = np.expand_dims(img, axis=0)  # Add a batch dimension


            # Predict the class label
            predictions = loaded_model.predict(img)
            predicted_class = np.argmax(predictions, axis=1)
            predicted_label = class_labels[predicted_class[0]]
            return jsonify({'predicted_label': predicted_label})
       except Exception as e:
            return jsonify({'error': 'An error occurred: {}'.format(str(e))})

if __name__ == '__main__':
    app.run(debug=True)
