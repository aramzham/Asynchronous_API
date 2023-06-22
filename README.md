# Asynchronous_API

Asynchronous APIs work a little bit differently than usual APIs where you need to wait for the response to come.
Check out this outstanding video by Les Jackson for more insight.[^1]

There are 3 main approaches of asynchronous communication.
<ul>
<li>Asynchronous request reply</li>
<li>Call back (webhooks)</li>
<li>Persistent connection (WebSockets, SignalR)</li>
</ul>

Here's how async request reply flow look like.
<img src="https://github.com/aramzham/Asynchronous_API/assets/25085025/537c5c38-9f60-4cc7-ace1-42570e25dedc" alt="async request reply"/>

Webhooks work a bit variously.
<img src="https://github.com/aramzham/Asynchronous_API/assets/25085025/739773a3-deed-4f63-9cb3-16d81c82f5cb" alt="webhook call back">

Persistent connection opens a possibility for a two way client-server communication.
<img src="https://github.com/aramzham/Asynchronous_API/assets/25085025/823591e4-0144-408a-a6f4-315b6052c332" alt="persistent connection">

[^1]: <a href="https://www.youtube.com/watch?v=LCbR58sCmvQ">link</a> to the tutorial