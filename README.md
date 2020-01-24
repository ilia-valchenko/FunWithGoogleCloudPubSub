# PubSub message schema
You can embed custom attributes as metadata in the message.
A server generarted ID unique within the topic. 
## How to batch messages
 - Send single message 
 - Send multiple messages per request
   - By request size (in bytes)
   - By number of messages
   - By time

```json
{
    "data": string,
    "attributes": {
        "string": string,
        ...
    },
    "messageId": string,
    "publishTime": string
}
```
