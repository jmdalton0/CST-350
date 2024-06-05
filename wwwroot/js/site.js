let game;
let games;

function displayGame() {
    let cells = game.cells;
    let board = document.getElementById('board');
    board.innerHTML = '';

    let DIM = Math.sqrt(cells.length);
    for (let i = 0; i < DIM; i++) {
        let row = document.createElement('div');
        row.classList.add('row', 'd-flex', 'justify-content-center');

        for (let j = 0; j < DIM; j++) {
            let ind = (DIM * i) + j;
            let cellBtn = document.createElement('button');
            cellBtn.classList.add('cell');

            let cell = cells[ind];
            if (cell.visited) {
                if (cell.live) {
                    cellBtn.classList.add('live');
                    cellBtn.innerText = '*';
                } else {
                    cellBtn.classList.add('visited');
                    if (cell.numLiveNeighbors > 0) {
                        cellBtn.innerText = cell.numLiveNeighbors;
                    }
                }
            } else {
                if (cell.flagged) {
                    cellBtn.classList.add('flagged');
                    cellBtn.innerText = 'F';
                } else {
                    cellBtn.classList.add('not-visited');
                }
            }

            cellBtn.addEventListener('click', (e) => {
                leftClick(ind);
            });

            cellBtn.addEventListener('contextmenu', (e) => {
                e.preventDefault();
                rightClick(ind);
            });

            row.appendChild(cellBtn);
        }

        board.appendChild(row);
    }
}

function displayGames() {
    let list = document.getElementById('games');
    list.innerHTML = "";

    for (let i = 0; i < games.length; i++) {
        let listItem = document.createElement('li');
        listItem.classList.add('game', 'd-flex', 'justify-content-between', 'align-items-center');

        let loadBtn = document.createElement('a');
        loadBtn.href = `/Home/Play/${games[i].id}`;
        loadBtn.innerText = games[i].id;

        let deleteBtn = document.createElement('button');
        deleteBtn.innerText = 'Delete';
        deleteBtn.classList.add('btn', 'btn-primary');
        deleteBtn.addEventListener('click', (e) => {
            deleteClick(games[i].id)
        });

        listItem.appendChild(loadBtn);
        listItem.appendChild(deleteBtn);
        list.appendChild(listItem);
    }
}

async function newGame() {
    let res = await fetch('/game/new');
    game = await res.json();
    displayGame();
}

async function allGames() {
    let res = await fetch('/game');
    games = await res.json();
    displayGames();
}

async function getGame(id) {
    let res = await fetch(`/game/${id}`);
    game = await res.json();
    displayGame();
}

async function deleteClick(id) {
    let res = await fetch(`/game/${id}`, {
        method: 'DELETE',
    });
    allGames();
}

async function leftClick(ind) {
    let res = await fetch(`/game/leftClick?ind=${ind}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(game),
    });
    game = await res.json();
    displayGame();
}

async function rightClick(ind) {
    let res = await fetch(`/game/rightClick?ind=${ind}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(game),
    });
    game = await res.json();
    displayGame();
}

