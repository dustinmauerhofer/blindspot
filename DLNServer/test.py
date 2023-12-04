import requests
import time

max_retries = 3
retry_delay = 5  # seconds

for attempt in range(1, max_retries + 1):
    resp = requests.post("https://foodprediction-f7xxgmeula-lm.a.run.app/predict", files={'file': open("blueberry.png", "rb")})

    if resp.status_code == 200:
        try:
            data = resp.json()
            print(data)
            break  # Break out of the loop if successful
        except requests.exceptions.JSONDecodeError:
            print("Error decoding JSON: Response does not contain valid JSON.")
            break  # Break out of the loop since it won't succeed on retries
    elif resp.status_code == 503:
        print(f"Attempt {attempt} failed with status code 503. Retrying in {retry_delay} seconds...")
        time.sleep(retry_delay)
    else:
        print(f"Request failed with status code: {resp.status_code}")
        break  # Break out of the loop for other non-retryable status codes
