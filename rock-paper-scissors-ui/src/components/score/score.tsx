import * as React from "react";
import { useState } from "react";

const Score = ({ result } : any) => {
  const [score, useScore] = useState(0);

  

  return (
    <div>
      <h2>Result: {result}</h2>
    </div>
  );
};

export default Score;