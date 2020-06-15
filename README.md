# XamarinToDoList

A simple ToDo list created using Xamarin Forms.


## Overview

The code provides a simple ToDo list to show a list of ToDo items, Add a new ToDo item and then either update or delete the item.

The REST server [ToDoListServer](https://github.com/mySimonID/TodoListServer/blob/master/README.md) is used to manage the interactions with the mongoDB which holds the ToDo items.

## Using

This project assumes that the [ToDoListServer](https://github.com/mySimonID/TodoListServer/blob/master/README.md) has been set-up on a Docker instance.

The file mongoDB.cs in the Services folder has a line: const string webService = "http://192.168.1.9:49160";

This refers to the instance of Docker that has been set-up on port 49160. If you specify a different port number or deploy the ToDoList Server to somewhere different, then change this reference.

Once this project is downloaded to your machine, compile as normal to an emulator.

## Future enhancements
- [ ] Implement authentication
- [ ] Implement auto-synch

## License
[MIT](https://choosealicense.com/licenses/mit/)

