import requests

API_URL = "http://localhost:5000/api/passwordEntries"

def add_password_entry(username, password, website):
    data = {
        "username": username,
        "password": password,
        "website": website
    }
    response = requests.post(f"{API_URL}", json=data)
    if response.status_code == 201:
        print("Password entry added!")
    else:
        print("Error adding entry:", response.text)

def retrieve_password_entries():
    response = requests.get(f"{API_URL}")
    if response.status_code == 200:
        entries = response.json()
        for entry in entries:
            print(entry)
    else:
        print("Error retrieving entries:", response.text)
