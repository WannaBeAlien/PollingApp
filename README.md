# Polling app

This project was created with Visual Studio using the React and .NET templates.

a simple polling application. and as of now, only the functionality for fetching and displaying the default poll is implemented.

HTTP requests are made using the Axios library.

Usage
Click the "Add Default Poll" button to fetch and display the default poll.

Endpoints
GET /api/polls/default: Fetch the default poll.
GET /api/polls: Fetch all polls.
GET /api/polls/{id}: Fetch a specific poll by ID.
POST /api/polls/add: Add a new poll.

Voting
POST /api/votes/{pollId}/vote/{optionId}: Vote for an option in a poll.
