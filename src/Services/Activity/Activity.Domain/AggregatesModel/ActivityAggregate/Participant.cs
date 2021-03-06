﻿using System;
using System.Collections.Generic;
using System.Text;
using Together.Activity.Domain.SeedWork;

namespace Together.Activity.Domain.AggregatesModel.ActivityAggregate
{
    public class Participant
        : Entity
    {
        public int UserId { get; private set; }

        public string Nickname { get; private set; }

        public string Avatar { get; private set; }

        public int ActivityId { get; private set; }

        public DateTime JoinTime { get; private set; }

        public Participant(int userId, string nickname, string avatar)
        {
            UserId = userId;
            Nickname = nickname;
            Avatar = avatar;

            JoinTime = DateTimeOffset.Now.DateTime;
        }
    }
}
