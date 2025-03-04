# Account and Customer Microservices
## Implementation includes
##  1.	API Gateway – OCELOT
##  2.	Consul – Service Discovery and Centralized Configuration[Download](https://developer.hashicorp.com/consul/install).
##          Run consul – cmd to directory and run command “consul agent -dev -node=localhost”
##  3.  JWT Authentication
##  4.	Authentication on API gateway for delete API’s  - User "admin", "aDm1n" has access to delete account or customer
##  5.	Validation from centralized key value using consul saved for emails to allow them to be the part of the system
##  6.	Exception handling – through middleware and customdelegatehandler middleware in api gateway for downstream api's
##  7. Logging through Ilogger interface injection

## **Please follow attached docs with images to test them**
