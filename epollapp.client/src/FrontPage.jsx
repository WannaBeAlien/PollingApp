// FrontPage.jsx
import React, { useState } from 'react';
import axios from 'axios';


const FrontPage = () => {
    const [poll, setPoll] = useState(null);
    const [newPoll, setNewPoll] = useState({ title: '', options: ['', '', '', ''] });
    

    const handleAddDefaultPoll = async () => {
        try {
            const response = await axios.get('http://localhost:5080/api/polls/default');
            setPoll(response.data);
        } catch (error) {
            console.error('Error fetching default poll:', error);
        }
    };
    const handleAddNewPoll = async () => {
        try {
            // Validate that title and options are not empty
            if (!newPoll.title.trim() || newPoll.options.some((option) => !option.trim())) {
                console.error('Title and all options must be filled.');
                return;
            }

            const response = await axios.post('http://localhost:5080/api/polls/add');
            setPoll(response.data);

            // Reset newPoll state after adding a new poll
            setNewPoll({ title: '', options: ['', '', '', ''] });
        } catch (error) {
            console.error('Error adding new poll:', error);
        }
    };

    const handleInputChange = (event, index) => {
        const { name, value } = event.target;

        if (name === 'title') {
            setNewPoll((prev) => ({ ...prev, title: value }));
        } else if (name.startsWith('option')) {
            const options = [...newPoll.options];
            options[index] = value;
            setNewPoll((prev) => ({ ...prev, options }));
        }
    };

    const handleVote = async (pollId, optionId) => {
        try {
            const response = await axios.post(`http://localhost:5080/api/votes/${pollId}/vote/${optionId}`);
            //await axios.get('http://localhost:5080/api/polls/default');
            setPoll(response.data);
        } catch (error) {
            console.error('Error voting:', error);
        }
    };



    return (
        <div>
            <h1>ePollApp</h1>
            <button onClick={handleAddDefaultPoll}>Add Default Poll</button>
            <div>
                <h2>Add New Poll</h2>
                <label>
                    Title:
                    <input type="text" name="title" value={newPoll.title} onChange={(e) => handleInputChange(e)} />
                </label>
                <br />
                <label>
                    Options:
                    {newPoll.options.map((option, index) => (
                        <input
                            key={index}
                            type="text"
                            name={`option${index}`}
                            value={option}
                            onChange={(e) => handleInputChange(e, index)}
                        />
                    ))}
                </label>
                <br />
                <button onClick={handleAddNewPoll}>Add New Poll</button>
            </div>
            {poll && (
                <div>
                    <h2>{poll.title}</h2>
                    <ul>
                        {poll.options.map((option) => (
                            <li key={option.id}>
                                {option.title} - Votes: {option.votes}
                                <button onClick={() => handleVote(poll.id, option.id)}>Vote</button>
                            </li>
                        ))}
                    </ul>
                </div>
            )}
        </div>
    );
};


export default FrontPage;
