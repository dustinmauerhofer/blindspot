import requests

resp = requests.post("http://localhost:5000/", files={'file': open('testing/milk.jpg','rb')})

print(resp.json())