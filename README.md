# PubSub message schema
You can embed custom attributes as metadata in the message.
A server generarted ID unique within the topic. 

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
