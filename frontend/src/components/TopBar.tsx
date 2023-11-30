import styled from 'styled-components';
import LanguageSelector from './LanguageSelector';

const TopBarWrapper = styled.div`
  background-color: #6eb5f5;
  color: #fff;
  padding: 2px;
  text-align: center;
  margin-bottom: 10px;
  display: flex;
  align-items: center;
`;

const DivRight = styled.div`
  margin-left: auto;
`;

const Title = styled.h3`
  margin: 10px;
`;

export interface TopBarInterface {
  title: string;
};

const TopBar = ({ title = '' }: TopBarInterface) => {
  return (
    <TopBarWrapper>
      <Title>{title}</Title>
      <DivRight>
        <LanguageSelector />
      </DivRight>
    </TopBarWrapper>
  );
}

export default TopBar;