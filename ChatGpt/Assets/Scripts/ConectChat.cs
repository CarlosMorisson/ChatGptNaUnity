using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;
using TMPro;
public class ConectChat : MonoBehaviour
{
    public TextMeshProUGUI chatText;
    private OpenAIApi openA = new OpenAIApi();
    private List<ChatMessage> messages = new List<ChatMessage>();
    public async void AskChatGPT(string newText)
    {
        ChatMessage newMessage = new ChatMessage();
        newMessage.Content = newText;
        newMessage.Role = "user";
        messages.Add(newMessage);
        CreateChatCompletionRequest request = new CreateChatCompletionRequest();
        request.Messages = messages;
        request.Model = "gpt-3.5-turbo";
        var response = await openA.CreateChatCompletion(request);
        if(response.Choices!=null && response.Choices.Count > 0)
        {
            var chatResponse = response.Choices[0].Message;
            messages.Add(chatResponse);
            chatText.text = chatResponse.Content;
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
