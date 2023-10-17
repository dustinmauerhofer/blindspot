import tensorflow as tf
import os
import cv2

data_dir = "data"
augment_dir = "augmented_data"
counter = 1;
name="augmented_picture"
def flip_left_to_right(image, class_dir):
    global counter
    flipped = cv2.flip(image, 1)  # Flip the image horizontally (1)
    file_path = os.path.join(class_dir, f"{name}{counter}.jpg")
    cv2.imwrite(file_path, flipped)
    counter += 1

def grayscale(image, class_dir):
    global counter
    grayscaled = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    file_path = os.path.join(class_dir, f"{name}{counter}.jpg")
    cv2.imwrite(file_path, grayscaled)
    counter += 1

def adjust_saturation(image, class_dir):
    global counter
    hsv = cv2.cvtColor(image, cv2.COLOR_BGR2HSV)
    saturation_factor = 3.0  # Adjust the saturation factor as desired
    hsv[..., 1] = hsv[..., 1] * saturation_factor
    saturated = cv2.cvtColor(hsv, cv2.COLOR_HSV2BGR)
    file_path = os.path.join(class_dir, f"{name}{counter}.jpg")
    cv2.imwrite(file_path, saturated)
    counter += 1

def adjust_brightness(image, class_dir):
    global counter
    brightness_factor = 0.4  # Adjust the brightness factor as desired
    bright = cv2.convertScaleAbs(image, alpha=brightness_factor, beta=0)
    file_path = os.path.join(class_dir, f"{name}{counter}.jpg")
    cv2.imwrite(file_path, bright)
    counter += 1

def central_crop(image, class_dir):
    global counter
    height, width = image.shape[:2]
    cropped = image[int(height * 0.25):int(height * 0.75), int(width * 0.25):int(width * 0.75)]
    file_path = os.path.join(class_dir, f"{name}{counter}.jpg")
    cv2.imwrite(file_path, cropped)
    counter += 1

def rotate_90(image, class_dir):
    global counter
    rotated = cv2.transpose(image)
    rotated = cv2.flip(rotated, 1)  # Rotate 90 degrees counterclockwise
    file_path = os.path.join(class_dir, f"{name}{counter}.jpg")
    cv2.imwrite(file_path, rotated)
    counter += 1

def augment(img, class_dir):
    flip_left_to_right(img, class_dir)
    grayscale(img, class_dir)
    adjust_saturation(img, class_dir)
    adjust_brightness(img, class_dir)
    central_crop(img, class_dir)
    rotate_90(img, class_dir)

def augment(img,class_dir):
    cv2.imwrite(os.path.join(class_dir, f"{name}{counter}.jpg"), img)
    print("check1")
    flip_left_to_right(img,class_dir)
    print("check2")
    grayscale(img,class_dir)
    print("check3")
    adjust_brightness(img,class_dir)
    print("check4")
    central_crop(img,class_dir)
    print("check5")
    rotate_90(img,class_dir)
    print("check6")

for image_class in os.listdir(data_dir):
    class_dir = os.path.join(augment_dir, f"{image_class}_augmented")

    if not os.path.exists(class_dir):
        os.makedirs(class_dir)

    for image in os.listdir(os.path.join(data_dir, image_class)):
        image_path = os.path.join(data_dir, image_class, image)
        try:
            img = cv2.imread(image_path)
            augment(img,class_dir)
            #print('Sucess reading!')
        except Exception as e:
            print('Issue with image {}'.format(image_path))
