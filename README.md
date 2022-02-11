# REST_API_with_JSON

Name: Jin Young Park 
WebServer: http://dbjyhw02server.us-west-2.elasticbeanstalk.com

I have implemented communication between webserver and client using REST API with JSON. I implemted REST API code using c# and Clouds Server used Amazon. The command-line tool used Talend API Tester.
 This program is a program to manage employee data. The employee's data, ID, FirstName, LastName, PayRate, StartDate, and EndDate, are stored in a database server in the cloud, connected to the web server. The web server receives the client's request, sends the request to the database server, and responds with REST API.


===Usage===
1. Start the command-line tool (ex)Talend API Tester).
2. Select the command you want from GET/POST/PUT/DELETE.

-GET: Show the data stored in the database server connected to web server.
1) Put the Web Server address and add '/api/Person', If you want to see all the data on the database server, http://dbjyhw02server.us-west-2.elasticbeanstalk.com/api/Person
Put the Web Server address and add '/api/Person/{id_number}', If you want data with a specific ID, http://dbjyhw02server.us-west-2.elasticbeanstalk.com/api/Person/{id_number}
2) Send. If successful, the server responds with 'OK', else if the ID does not exist in the database server, the server responds with 'Not Found'.

-POST: Add data to the database server.
1) Put the Web Server address and add '/api/Person, http://dbjyhw02server.us-west-2.elasticbeanstalk.com/api/Person
2) Write the desired data in JSON format.
example)
{
"FirstName": "JinYoung",
"LastName": "Park",
"PayRate": 32.23,
"StartDate": "1990-12-10T00:00:00",
"EndDate": "1991-10-10T00:00:00"
}
3) Send. If successful, the server responds with 'Created'. ( If you want to see if the data has been added after sending, send a GET.)

-PUT: Update data to the data server
1) Put the Web Server address, add '/api/Person and add the id number you want to update, http://dbjyhw02server.us-west-2.elasticbeanstalk.com/api/Person/{id_number}
2) Write the data you want to change with JSON
example)
{
"FirstName": "JinYoung",
"LastName": "Park",
"PayRate": 50.78,
"StartDate": "1990-12-10T00:00:00",
"EndDate": "1991-10-10T00:00:00"
}
3) Send. If successful, the server responds with 'Accepted', else if the ID does not exist in the database server, the server responds with 'Not Found'. '. ( If you want to see if the data has been added after sending, send a GET.)

-DELETE: Delete data on the database server.
1) Put the Web Server address, add '/api/Person and add the id number you want to delete, http://dbjyhw02server.us-west-2.elasticbeanstalk.com/api/Person/{id_number}
2) Send. If successful, the server responds with 'No Content', else if the ID does not exist in the database server, the server responds with 'Not Found'. ( If you want to see if the data has been added after sending, send a GET.)


===Description===
First of all, The project uses an 'ASP.NET web application' to handle client requests and the code is implmented to do the above. Employee data, which is the input or output value to communicate, is created as an ArrayList using the class. And I refereced MySQL and put the database's address, id, pw, port number, and database name in the ConnectString to connect to the database server.
In the case of servers, I created a sql database using RDS on Amazon. The web server was created automatically by deploying the code in Visual Studio. The database and web server created then consisted of a network interface consisting of subnets.


