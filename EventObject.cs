using System;

namespace project_stub {

    /*
     * EventObject is used to store information about an event and pass it to
     * other processes.
     */
    public class EventObject {
        public string EventType { get; set; }
        public string EventContents { get; set; }
        public object EventStore { get; set; }
    }
}
