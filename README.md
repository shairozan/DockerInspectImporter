# DockerInspectImporter
Takes the guesswork (minus network names) out of re-creating your docker service definitions. As long as you have the JSON output from `docker service inspect <service>`, this will create the docker service create lines needed to re-create everything. 

When the console runs, just give it the path to the location in which you have saved the JSON files and it will run through them all producing two things:

1. The docker service create commands for each service
2. A list of discrete images that will need to be pulled onto the application servers
