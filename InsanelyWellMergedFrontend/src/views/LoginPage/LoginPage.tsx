import { Button, TextField } from '@mui/material';
import { StyledLoginPage } from './styled/StyledLoginPage';
import StyledButtonContainer from './styled/StyledButtonContainer';
import { useNavigate } from 'react-router-dom';

const LoginPage = () => {
  const navigate = useNavigate();

  const handleLogin = () => {
    console.log('Login');
    navigate('/home');
  };

  return (
    <StyledLoginPage>
      <h1>Login Page</h1>
      <TextField required id="standard-basic" label="Username" variant="standard" />
      <TextField required id="standard-basic" label="Password" variant="standard" />
      <StyledButtonContainer>
        <Button variant="outlined">Register</Button>
        <Button onClick={handleLogin} variant="contained">
          Login
        </Button>
      </StyledButtonContainer>
    </StyledLoginPage>
  );
};

export default LoginPage;
