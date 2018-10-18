System Architecture 

dsnl HMO Manager is design as a Client/Server application: This is a network with a traditional server acting as a central unit (the primary server) with several workstations connecting to it. The server is where you store the company data that will be connected to by workstations. Examples of client/server networks compatible with dsnl HMO Manager include Windows 2003 Server and Windows 2012 Server or higher and Microsoft SQL Server is installed as the database management software for dsnl HMO.
  dsnl HMO can run on two types of networks: peer-to-peer and client/server. 

Quick Tips for Network Install
Use the following tips to help you install dsnl HMO Manager on a network:
?	Always install dsnl HMO Manager FIRST on the Server that will store your dsnl HMO data files; that is, those files that record your dsnl HMO transactions and records. 
?	Restore the database on MS SQL Server on the server and create account for all users on your active directory and MS SQL Server then give the require right and privileges
?	Install dsnl HMO on each workstation. Each computer that will have dsnl HMO operating on it must have dsnl HMO installed on it.

