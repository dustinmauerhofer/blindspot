import numpy as np
import tensorflow as tf
import sys
from PIL import Image

if __name__ == "__main":
    if len(sys.argv) != 2:
        print("Usage: python your_script.py <picture>")
        sys.exit(1)

    picture_parameter = sys.argv[1]

    try:
        loaded_model = tf.keras.models.load_model("augmentedV1.5")
        img = Image.open(picture_parameter)
        img = img.resize((256, 256))  # Resize the image to the desired size
        img = np.array(img) / 255.0  # Normalize the image to [0, 1]
        img = np.expand_dims(img, axis=0)

        predictions = loaded_model.predict(img)

        predicted_class = np.argmax(predictions, axis=1)

        class_labels = ["apple", "blueberry", "milk", "orange", "pear"]
        predicted_label = class_labels[predicted_class[0]]
        print(predicted_label)
    except Exception as e:
        print("An error occurred:", e)
