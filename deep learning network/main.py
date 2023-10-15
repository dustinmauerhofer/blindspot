
import tensorflow as tf
import os
import cv2
import imghdr

from keras.models import Sequential
<<<<<<< HEAD
from keras.layers import Conv2D, MaxPooling2D, Dense, Flatten, Dropout, BatchNormalization
=======
from keras.layers import Conv2D, MaxPooling2D, Dense, Flatten, Dropout
from keras.saving.saving_api import load_model
>>>>>>> parent of c5c1f28 (dln works now)

gpus = tf.config.experimental.list_physical_devices('GPU')
for gpu in gpus:
    tf.config.experimental.set_memory_growth(gpu, True)

data_dir = 'data'
image_exts = ['jpeg', 'jpg', 'bmp', 'png']
num_classes = len(os.listdir(data_dir));
# Clean out dodgy images

for image_class in os.listdir(data_dir):
    for image in os.listdir(os.path.join(data_dir, image_class)):
        image_path = os.path.join(data_dir, image_class, image)
        try:
            img = cv2.imread(image_path)
            tip = imghdr.what(image_path)
            if tip not in image_exts:
                print('Image not in ext list {}'.format(image_path))
                os.remove(image_path)
        except Exception as e:
            print('Issue with image {}'.format(image_path))
            # os.remove(image_path)

# Load data

data = tf.keras.utils.image_dataset_from_directory('data',)

# Preprocess Data
data = data.map(lambda x, y: (x / 255, tf.one_hot(y, depth=num_classes)))

print(data)
# Split data

train_size = int(len(data) * 0.7)  # used to train the data
val_size = int(len(data) * 0.2)    # used to validate the data
test_size = int(len(data) * 0.1) + 1  # used to test the data

train = data.take(train_size)
val = data.skip(train_size).take(val_size)
test = data.skip(train_size + val_size).take(test_size)

# Data Agumentation Layers

<<<<<<< HEAD


# Deep Learning

model = Sequential()

model.add(Conv2D(64, (3, 3),1, activation='relu', input_shape=(256, 256, 3)))
model.add(BatchNormalization())
model.add(MaxPooling2D())

model.add(Conv2D(128, (3, 3),1, activation='relu',))
model.add(BatchNormalization())
model.add(MaxPooling2D())

model.add(Conv2D(64, (3, 3),1, activation='relu',))
model.add(BatchNormalization())
model.add(MaxPooling2D())

model.add(Conv2D(64, (3, 3),1, activation='relu',))
model.add(BatchNormalization())
model.add(MaxPooling2D())

model.add(Conv2D(64, (3, 3),1, activation='relu',))
model.add(BatchNormalization())
=======
model = Sequential()

model.add(Conv2D(16, (3, 3), 1, activation='relu', input_shape=(256, 256, 3)))
model.add(MaxPooling2D())

model.add(Conv2D(32, (3, 3), 1, activation='relu'))
model.add(MaxPooling2D())

model.add(Conv2D(16, (3, 3), 1, activation='relu'))
>>>>>>> parent of c5c1f28 (dln works now)
model.add(MaxPooling2D())

model.add(Dense(num_classes, activation='softmax'))

model.compile(optimizer='adam', loss='categorical_crossentropy', metrics=['accuracy'])

# Train the model

logdir = 'logs'
tensorboard_callback = tf.keras.callbacks.TensorBoard(log_dir=logdir)

hist = model.fit(train, epochs=20, validation_data=val, callbacks=[tensorboard_callback])


<<<<<<< HEAD
#model.save("AugmentedV1.h5");
=======
model.save("apple_pear_orange_blueberry_testV2.h5");


# test



>>>>>>> parent of c5c1f28 (dln works now)

# Evaluate Performance

precision = tf.keras.metrics.Precision()
recall = tf.keras.metrics.Recall()
accuracy = tf.keras.metrics.CategoricalAccuracy()

for batch in test.as_numpy_iterator():
    X, y = batch
    yhat = model.predict(X)
    precision.update_state(y, yhat)
    recall.update_state(y, yhat)
    accuracy.update_state(y, yhat)

print(f'Precision: {precision.result().numpy()}, Recall: {recall.result().numpy()}, Accuracy: {accuracy.result().numpy()}')


#https://www.datacamp.com/tutorial/complete-guide-data-augmentation