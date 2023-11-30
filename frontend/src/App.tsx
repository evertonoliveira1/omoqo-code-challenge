import { Container } from '@mui/material';
import React from 'react';
import { Route, BrowserRouter as Router, Routes } from 'react-router-dom';

import { I18nextProvider, useTranslation } from 'react-i18next';
import TopBar from './components/TopBar';
import i18n from './i18n/i18n';
import CreatePage from './pages/ship/Form/CreatePage';
import EditPage from './pages/ship/Form/EditPage';
import ListPage from './pages/ship/List/ListPage';

const App: React.FC = () => {
  const { t } = useTranslation();

  return (
    <>
        <Container>
          <TopBar title={t("systemTitle")} />

          <Router>
            <I18nextProvider i18n={i18n}>
              <Routes>
                <Route path="/" element={<ListPage />} />
                <Route path="/create" element={<CreatePage />} />
                <Route path="/update/:id" element={<EditPage />} />
              </Routes>
            </I18nextProvider>
          </Router>
        </Container>
    </>

  );
};

export default App;
