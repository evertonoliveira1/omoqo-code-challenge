import { CircularProgress } from '@mui/material';
import styled from 'styled-components';

const DivLoading = styled.div`
    display: 'flex';
    justifyContent: 'center';
    alignItems: 'center';
    height: '100vh';
`

const Loading = () => {
    return (
        <DivLoading>
            <CircularProgress />
        </DivLoading>
    );
};

export default Loading;
