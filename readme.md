# Interview MVC application

## Description
    - This app has layered arch with repositories and services which provide clean business logic. 
    It uses MSSQL database which is hosted in localhost.
    The server is containerized with docker. 

    - MVC pattern with razor pages are used for this special project. 
    Inserting a csv file, storing fields in db and getting data from it
    is realised via controllers and other BL. 

    - For front end razor pages are being used in combination with js and css files
    for filtering data by column, sorting by any field and inline editing.
    

## How to start a project
    Firslty, there is already a test.csv file which is located in src folder.

    Secondly, you have to start container buy running command: 
    docker-compose up -d

    Lastly, run application.
