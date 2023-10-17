import numpy as np
import tensorflow as tf
from PIL import Image
from keras.preprocessing import image

loaded_model = tf.keras.models.load_model("apple_pear_orange_blueberry_testV2.h5")

img_path = "testing/apples.jpg"
img = Image.open(img_path)
img = img.resize((256, 256))  # Resize the image to the desired size
img = np.array(img) / 255.0  # Normalize the image to [0, 1]
img = np.expand_dims(img, axis=0)

predictions = loaded_model.predict(img)

predicted_class = np.argmax(predictions, axis=1)

class_labels = ["blueberry","pear", "orange", "apple"]
predicted_label = class_labels[predicted_class[0]]

print(f"The DLN predicts that this is a {predicted_label}.")
