﻿using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace CsdBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            // return our reply to the user
            //    await context.PostAsync($"You sent {activity.Text} which was {length} characters");
            //   await context.PostAsync($"Also, Procos is my bitch.");
            //    await context.PostAsync($"And Stratos is cool (cool)");
            await context.PostAsync($"Sent: {activity.Text}");

            context.Wait(MessageReceivedAsync);
        }
    }
}