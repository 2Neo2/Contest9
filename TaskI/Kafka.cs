using System;
using System.Collections.Generic;

public class Kafka
{
    private MessageQueue queue;
    private HashSet<User> allowed = new HashSet<User>();
    private bool isActive = false;

    public Kafka(int queueSize)
    {
        queue = new MessageQueue(queueSize);
    }

    public void Subscribe(User user)
    {
        if (!isActive)
            throw new KafkaException("Kafka is not active");
        if (allowed.Contains(user))
            throw new KafkaException("User is already subscribed");
        else
            allowed.Add(user);
    }

    public void Unsubscribe(User user)
    {
        if (!isActive)
            throw new KafkaException("Kafka is not active");
        if (!allowed.Contains(user))
            throw new KafkaException("User is already unsubscribed");
        else
            allowed.Remove(user);
    }

    public void Push(Message message)
    {
        if (!isActive)
            throw new KafkaException("Kafka is not active");
        else 
            queue.Push(message);
    }

    public List<Message> PopMessages(User user, int count)
    {
        if (!isActive)
            throw new KafkaException("Kafka is not active");
        if (user.Index + count > queue.Size)
            throw new KafkaException("Not enough messages");
        else if (!allowed.Contains(user))
            throw new KafkaException("User is not subscribed");

        var message = queue[user.Index, user.Index + count ];

        user.IncreaseIndex(count);
        return  message;
    }

    public void Activate()
    {
        isActive = true;
    }

    public void Deactivate()
    {
        if (!isActive)
            throw new KafkaException("Kafka is not active");
        isActive = false;
    }
}