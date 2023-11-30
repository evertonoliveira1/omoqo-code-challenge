import { Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useTranslation } from "react-i18next";
import { useNavigate, useParams } from "react-router-dom";
import EntryForm from "./EntryForm";

import ErrorDialog from "../../../components/ErrorDialog";
import Loading from "../../../components/Loading";
import { ShipData } from "../../../interfaces/Ship";
import { getRequest, putRequest } from "../../../services/baseApi";

const EditPage = () => {
  const { t } = useTranslation();
  const navegate = useNavigate();
  const [shipData, setShipData] = useState();
  const { id: idString } = useParams();

  const [errorMessage, setErrorMessage] = useState('');
  const [openDialog, setOpenDialog] = useState(false);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await getRequest(`ship/${idString}`);
        setShipData(response);
        setLoading(false);
      } catch (err: any) {
        setErrorMessage(err.message);
        setOpenDialog(true);
      }
    };

    fetchData();
  }, []);

  const handleFormSubmit = async (data: ShipData) => {
    try {
      await putRequest(`ship/${idString}`, data);
      navegate('/');
    } catch (err: any) {
      setErrorMessage(err.message);
      setOpenDialog(true);
      setLoading(false);
    }
  };

  return (
    <div>
      <ErrorDialog currentStatus={openDialog} message={errorMessage} />
      <Typography variant="h5">{t('updatePageTitle')}</Typography>

      {shipData && (<EntryForm onSubmit={handleFormSubmit} initialData={shipData} />)}
      {loading && (<Loading />)}
    </div>
  );
};

export default EditPage;