import * as React from "react";
import { useState } from "react";
import axios from 'axios';
import Score from '../score/score';
import { PlayerChoices, PlayerType, GameResult, GameSettings } from "../../types";
import './game.scss';

const Game = () => {
  const [gameResult, setGameResult] = useState('');
  const [score, setScore] = useState(0);
  const [playerType, setPlayerType] = useState(PlayerType.player);

  const handleChoiceClick = (settings: GameSettings) => {
    axios.post(`https://localhost:7223/api/game`, { Choice: settings?.Choice, PlayerType: settings.PlayerType })
      .then((response: any) => {
        validateResult(response?.data?.result);
      })
      .catch((error: any) => {
        console.error('Error:', error);
        setGameResult('Error could not get result');
      });
  };

  const validateResult = (game: GameResult) => {
    if (game.isSuccess) {
      setGameResult(`${ game.result } - ${PlayerType[game.winner]} wins!`);
      updateScore(game.winner);
    } else {
      setGameResult('Error could not get result');
    }
  }

  const updateScore = (winner: PlayerType) => {
    if (winner === PlayerType.player) {
      setScore(score + 1);
    }
  }

  const handleSelect = (event: any) => {
    const selectedType = Number(event.target.value) as PlayerType;
    setPlayerType(selectedType);
  }

  return (
    <div className='game'>
      <div className='title'>Rock Paper Scissors</div>
      <select onChange={(e) => handleSelect(e)}>
        <option value={PlayerType.player}>player vs computer</option>
        <option value={PlayerType.computer}>computer vs computer</option>
      </select>
      { playerType === PlayerType.player && <h2>{` ${PlayerType[playerType]} score:`} {score}</h2> }
      <div className='actions'>
        {playerType === PlayerType.player && PlayerChoices.map((choice: string) => (<button key={choice} onClick={() => handleChoiceClick({ Choice: choice, PlayerType: playerType })}>{choice}</button>))}
        {playerType === PlayerType.computer && <button onClick={() => handleChoiceClick({ PlayerType: playerType })}>Get Result</button>}
      </div>
      {gameResult && <Score result={gameResult} />}
    </div>
  );
};

export default Game;