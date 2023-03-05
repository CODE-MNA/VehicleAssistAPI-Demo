# Application Logic

## Folders for each usecase / aggregrate

## Just Single file with 3-4 classes i.e 1 class for a request record object, validation , handling and response record object

## Try adding least amount of logic here (Logic that relates to using interfaces that are implemented by infrastructure)

## This glues together the Infrastructure with the domain (our business related classes) entites 

## So try avoiding writing logic that directly relates to our business (checking if customer has any vehicles)
## Write logic like "use file storage service to save the image passed in the request object and store the link in the vehicle object" here