using System;
using System.Security.Cryptography;
using System.Text;

namespace ObjectOrientedProgramming.Lab3.Mail;

public class Message : IEquatable<Message>
{
    private Message(Builder builder)
    {
        Header = builder.Header;
        Body = builder.Body;
        Importance = builder.Importance;
    }

    public int Importance { get; }
    private string? Header { get; }
    private string? Body { get; }

    public string GetText()
    {
        return new StringBuilder().Append(Header).Append(Body).ToString();
    }

    public bool Equals(Message? other)
    {
        return Body != null && Header != null && Header.Equals(other?.Header, StringComparison.Ordinal) && Body.Equals(other.Body, StringComparison.Ordinal) && Importance == other.Importance;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Message);
    }

    public override int GetHashCode()
    {
        return BitConverter.ToInt32(SHA256.HashData(Encoding.ASCII.GetBytes(new StringBuilder().Append(Header).Append(Body).Append(Importance).ToString())));
    }

    public class Builder
    {
        public string? Header { get; private set; }
        public string? Body { get; private set; }
        public int Importance { get; private set; }

        public Builder SetHeader(string? header)
        {
            Header = header + '\n';
            return this;
        }

        public Builder SetBody(string? body)
        {
            Body = body + '\n';
            return this;
        }

        public Builder SetImportance(int importance)
        {
            Importance = importance;
            return this;
        }

        public Message Build()
        {
            return new Message(this);
        }
    }
}