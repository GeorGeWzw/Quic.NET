﻿using QuicNet.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuicNet.Infrastructure.Connections
{
    /// <summary>
    /// Since UDP is a stateless protocol, the ConnectionPool is used as a Conenction Manager to 
    /// route packets to the right "Connection".
    /// </summary>
    public static class ConnectionPool
    {
        /// <summary>
        /// Starting point for connection identifiers.
        /// ConnectionId's are incremented sequentially by 1.
        /// </summary>
        private static UInt32 _connectionIdIterator = 0;

        private static Dictionary<UInt32, QuicConnection> _pool = new Dictionary<UInt32, QuicConnection>();

        public static bool AddConnection(UInt32 id)
        {
            if (_pool.ContainsKey(id))
                return false;

            if (_pool.Count > QuicSettings.MaximumConnectionIds)
                return false;

            _pool.Add(id, new QuicConnection(id));

            return true;
        }
    }
}