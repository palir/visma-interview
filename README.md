# visma-interview
Pub/Sub solution for an interview

This solution was created as a Publish/Subscribe pattern technical exercise for an job apply interview at Visma.
It does not contain everything that a real application should.

The most important limitations:

1. Missing dependency injection
2. Only demonstrative unit tests coverage
3. No network communication - only delegate used to demonstrate message transport
4. Missing message queue and message delivery confirmation
5. Just very basic level of exception handling and logging

Created using VS2022/NET.6

Example of use is in Program.cs file in PubSubPresentationConsole.

