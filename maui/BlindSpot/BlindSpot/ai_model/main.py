import tensorflow as tf
import sys

if __name__ == "__main__":
    if len(sys.argv) != 2:
        print("Usage: python your_script.py <picture>")
        sys.exit(1)

    picture_parameter = sys.argv[1]

model = tf.keras.models.load_model('augmentedV1.h5')

