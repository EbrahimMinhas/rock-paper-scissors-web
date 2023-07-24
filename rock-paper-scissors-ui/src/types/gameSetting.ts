import { PlayerType } from "./playerTypes"

export interface GameSettings {
  Choice?: string,
  PlayerType: PlayerType
}


export interface GameResult {
  winner: PlayerType
}