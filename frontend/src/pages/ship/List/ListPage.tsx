import AddIcon from '@material-ui/icons/Add';
import { Button } from '@mui/material';
import React, { useEffect, useState } from 'react';
import { useTranslation } from 'react-i18next';
import styled from 'styled-components';

import { Grid, Paper } from '@material-ui/core';
import TextField from '@material-ui/core/TextField';
import DeleteConfirmationDialog from '../../../components/DeleteConfirmationDialog';
import BasicTable from '../../../components/Table';
import { Ship } from "../../../interfaces/Ship";
import { deleteRequest, getRequest } from '../../../services/baseApi';

const Wrapper = styled.div`
  display: flex;
  align-items: center;
`;

const DivRight = styled.div`
  margin-left: auto;
`;

const ListPage: React.FC = () => {
  const { t } = useTranslation();
  const [openDialog, setOpenDialog] = useState(false);
  const [idDeletion, setIdDeletion] = useState();
  const [ships, setShips] = useState([] as Ship[]);
  const [page, setPage] = useState(0);
  const [count, setCount] = useState(0);
  const [codeFilter, setCodeFilter] = useState('');
  const [rowsPerPage, setRowsPerPage] = React.useState(10);
  
  useEffect(() => {
    const fetchData = async () => {
      try {
        const params = {
          page,
          limit: rowsPerPage,
          code: codeFilter
        };
        const response = await getRequest('ship', params);
        setShips(response.data);
        setCount(response.count);
      } catch (err) {
        setShips([]);
      }
    };

    fetchData();
  }, [codeFilter, page, rowsPerPage]);

  const handleChangePage = (
    _: React.MouseEvent<HTMLButtonElement> | null,
    newPage: number,
  ) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(1);
  };

  const handleDelete = (id: any) => {
    setIdDeletion(id);
    setOpenDialog(true);
  }

  const handleConfirm = async () => {
    await deleteRequest(`ship/${idDeletion}`);
    const newShipArray = ships.filter(item => item.id !== idDeletion);
    setShips(newShipArray);
    setCount(newShipArray.length-1)
    setOpenDialog(false);
  };

  const handleChangeCodeFilter = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    setCodeFilter(event.target.value);
    setPage(0);
  }

  return (
    <>
      <DeleteConfirmationDialog currentStatus={openDialog} handleConfirm={handleConfirm} />

      <Grid container spacing={3}>

        <Grid item xs={6}>
          <Paper style={{ padding: 16 }}>
            <TextField
              label={t('code')}
              name="code"
              value={codeFilter}
              onChange={handleChangeCodeFilter}
              margin="normal"
              fullWidth
            />
          </Paper>
        </Grid>
      </Grid>
      <Wrapper>
        <DivRight>
          <Button
            variant="contained"
            color="primary"
            style={{ marginBottom: "10px" }}
            startIcon={<AddIcon />}
            href='/create'
          >
            {t("addButton")}
          </Button>
        </DivRight>
      </Wrapper>
      <>
        <BasicTable rows={ships || []}
          handleDelete={handleDelete}
          page={page}
          count={count}
          rowsPerPage={rowsPerPage}
          handleChangePage={handleChangePage}
          handleChangeRowsPerPage={handleChangeRowsPerPage}
        />
      </>
    </>
  );
};

export default ListPage;