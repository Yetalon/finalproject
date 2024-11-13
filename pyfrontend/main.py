import PySimpleGUI as sg

# Define layouts for each tab (page)
add_entry_layout = [
    [sg.Text("Username"), sg.InputText(key="username")],
    [sg.Text("Password"), sg.InputText(key="password", password_char="*")],
    [sg.Text("Website"), sg.InputText(key="website")],
    [sg.Button("Add", key="add_button")],
    [sg.Text("", size=(40, 1), key="add_status", text_color="green")]
]

view_entries_layout = [
    [sg.Text("Saved Entries")],
    [sg.Output(size=(50, 10), key="output")],
    [sg.Button("Refresh", key="refresh_button")]
]

update_entry_layout = [
    [sg.Text("Update an Entry")],
    [sg.Text("Username"), sg.InputText(key="update_username")],
    [sg.Text("New Password"), sg.InputText(key="update_password", password_char="*")],
    [sg.Button("Update", key="update_button")],
    [sg.Text("", size=(40, 1), key="update_status", text_color="green")]
]

# Define the tab layout
tab_layout = [
    [sg.Tab("Add Entry", add_entry_layout)],
    [sg.Tab("View Entries", view_entries_layout)],
    [sg.Tab("Update Entry", update_entry_layout)]
]

# Create the main window layout with tabs
layout = [[sg.TabGroup([tab_layout])]]
window = sg.Window("Password Manager", layout)

# Event loop
while True:
    event, values = window.read()
    if event == sg.WINDOW_CLOSED:
        break
    elif event == "add_button":
        # Handle add entry logic
        window["add_status"].update("Entry added successfully!")
    elif event == "refresh_button":
        # Handle view entries logic
        window["output"].update("Displaying entries...")
    elif event == "update_button":
        # Handle update entry logic
        window["update_status"].update("Entry updated successfully!")

window.close()
