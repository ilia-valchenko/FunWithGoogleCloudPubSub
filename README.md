# PubSub message schema
You can embed custom attributes as metadata in the message.

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
