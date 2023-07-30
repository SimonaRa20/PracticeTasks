import React, { useState, useEffect } from 'react';
import { Container, Box, Grid, Button } from '@mui/material';

export default function App() {
  const [questions, setQuestions] = useState<any[]>([]);
  const [currentQuestion, setCurrentQuestion] = useState<number>(0);
  const [showScore, setShowScore] = useState<boolean>(false);
  const [score, setScore] = useState<number>(0);
  const [gameOver, setGameOver] = useState<boolean>(false);

  useEffect(() => {
    fetch('https://opentdb.com/api.php?amount=10')
      .then((response) => response.json())
      .then((data) => {
        const formattedQuestions = data.results.map((result: any) => ({
          questionText: decodeHTML(result.question),
          answerOptions: [
            { answerText: decodeHTML(result.correct_answer), isCorrect: true },
            ...result.incorrect_answers.map((incorrectAnswer: string) => ({
              answerText: decodeHTML(incorrectAnswer),
              isCorrect: false,
            })),
          ],
        }));
        setQuestions(formattedQuestions);
      })
      .catch((error) => console.error('Error fetching data:', error));
  }, []);

  const handleAnswerOptionClick = (isCorrect: boolean) => {
    if (isCorrect) {
      setScore(score + 1);
    }

    const nextQuestion = currentQuestion + 1;
    if (nextQuestion < questions.length) {
      setCurrentQuestion(nextQuestion);
    } else {
      setShowScore(true);
      setGameOver(true);
    }
  };

  const resetGame = () => {
    setScore(0);
    setCurrentQuestion(0);
    setShowScore(false);
    setGameOver(false);
  };

  const decodeHTML = (html: string) => {
    const txt = document.createElement('textarea');
    txt.innerHTML = html;
    return txt.value;
  };

  return (
    <Container>
      <Box sx={{
        border: 1,
        display: 'flex',
        justifyContent: 'center', // Center horizontally
        alignItems: 'center', // Center vertically
        minHeight: '100vh', // Ensure the box covers the entire viewport height
        boxSizing: 'border-box',
        backgroundColor: 'white', // Add a background color to create a card-like effect
        padding: '20px',
      }}>
      {showScore ? (
        <Box display="flex" flexDirection="column" justifyContent="center" alignItems="center">
          <Box mb={4}>
            <div className='score-section'>
              You scored {score} out of {questions.length}
            </div>
          </Box>
          <Box>
            {gameOver && (
              <Button onClick={resetGame} variant="contained">
                Play Again
              </Button>
            )}
          </Box>
        </Box>
      ) : (
        <Box

        >
          <Box textAlign="center" mb={4}>
            <div className='question-text'>{questions[currentQuestion]?.questionText}</div>
          </Box>
          <Box textAlign="center" mb={4}>
            <Grid container spacing={2} justifyContent="center">
              {questions[currentQuestion]?.answerOptions.map((answerOption: any, index: number) => (
                <Grid key={index} item>
                  <Button variant="outlined" onClick={() => handleAnswerOptionClick(answerOption.isCorrect)}>
                    {answerOption.answerText}
                  </Button>
                </Grid>
              ))}
            </Grid>
          </Box>
          <Box textAlign="center" mb={4}>
            <div className='question-count'>
              Question {currentQuestion + 1}/{questions.length}
            </div>
          </Box>
        </Box>
      )}
      </Box>
      
    </Container>
  );
}
