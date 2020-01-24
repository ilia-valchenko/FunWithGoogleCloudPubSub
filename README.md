# PubSub message schema
You can embed custom attributes as metadata in the message.
A server generarted ID unique within the topic. 
## How to batch messages
 - Send multiple messages per request

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
