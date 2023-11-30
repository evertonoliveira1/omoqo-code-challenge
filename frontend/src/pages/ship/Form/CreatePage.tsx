import { Typography } from "@mui/material";
import { useState } from "react";
import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";
import ErrorDialog from "../../../components/ErrorDialog";
import { ShipData } from "../../../interfaces/Ship";
import { postRequest } from "../../../services/baseApi";
import EntryForm from "./EntryForm";

const CreatePage = () => {
  const { t } = useTranslation();

  const navegate = useNavigate();

  const [errorMessage, setErrorMessage] = useState('');
  const [openDialog, setOpenDialog] = useState(false);

  const handleFormSubmit = async (shipData: ShipData) => {
    try {
      await postRequest('ship', shipData);
      navegate('/');
    } catch (err: any) {
      setErrorMessage(err.message);
      setOpenDialog(true);
    }
  };

  return (
    <div>
      <ErrorDialog currentStatus={openDialog} message={errorMessage} />
      <Typography variant="h5">{t('createPageTitle')}</Typography>
      <EntryForm onSubmit={handleFormSubmit} />
    </div>
  );

}

export default CreatePage;