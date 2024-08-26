# Elumini.Test.ToDo

Logs >> ..\Adapters\Elumini.Test.ToDo.Api\Logs

Arquitetura Hexagonal - Exemplo

       +------------------------------------------+
       |                                          |
       |            Application Core              |
       |       (Domain and Business Rules)        |
       |                                          |
       |    +-------------------------------+     |
       |    |                               |     |
       |    |           Interfaces          |     |
       |    |        IToDoQueuePublisher      |     |
       |    |   (Port / Output Interface)   |     |
       |    +-------------------------------+     |
       |                                          |
       +----------------------+-------------------+
                              |
                              |
           +------------------+------------------+
           |                                     |
           |               Adapters              |
           |                                     |
+----------------------+        +--------------------------------+
|                      |        |                                |
| External Systems     |        | Infrastructure Layer           |
|   (Inputs)           |        |  (Outputs)                     |
|                      |        |                                |
| +------------------+ |        | +----------------------------+ |
| |                  | |        | |                            | |
| | WebAPI           | |        | | IToDoQueuePublisher        | |
| |                  | |        | | QueuePublisher             | |
| +------------------+ |        | | (QueuePublisher Imp.)      | |
|                      |        | |                            | |
|                      |        | +----------------------------+ |
|                      |        |                                |
|                      |        | +----------------------------+ |
|                      |        | |                            | |
|                      |        | | PaypalPayment              | |
|                      |        | | Processor                  | |
+----------------------+        | | (IPaymentProcessor Imp.)   | |
                                | |                            | |
                                | +----------------------------+ |
                                |                                |
                                +--------------------------------+ 
