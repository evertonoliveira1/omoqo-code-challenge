import { Grid, Paper } from '@material-ui/core';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import ArrowBackIcon from '@material-ui/icons/ArrowBack';
import SaveIcon from '@material-ui/icons/Save';
import React, { useState } from 'react';
import { useTranslation } from 'react-i18next';
import styled from 'styled-components';
import { ShipData } from '../../../interfaces/Ship';

interface ShipFormProps {
  onSubmit: (shipData: ShipData) => void;
  initialData?: ShipData;
}

const Wrapper = styled.div`
  display: flex;
  align-items: center;
`;

const DivRight = styled.div`
  margin-top: 5px;
  margin-left: auto;
`;

const EntryForm: React.FC<ShipFormProps> = ({ onSubmit, initialData }) => {
  const { t } = useTranslation();
  const [formData, setFormData] = useState<ShipData>(
    initialData || {
      name: '',
      length: 0,
      width: 0,
      code: '',
    }
  );

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({ ...prevData, [name]: value }));
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit(formData);
  };

  return (
      <form onSubmit={handleSubmit}>
        <>
          <Grid container spacing={3}>

            <Grid item xs={6}>
              <Paper style={{ padding: 16 }}>
                <TextField
                  label={t('name')}
                  name="name"
                  value={formData.name}
                  onChange={handleChange}
                  margin="normal"
                  fullWidth
                  required
                />
              </Paper>
            </Grid>

            <Grid item xs={6}>
              <Paper style={{ padding: 16 }}>
                <TextField
                  label={t('formatCodePattern')}
                  name="code"
                  value={formData.code}
                  onChange={handleChange}
                  margin="normal"
                  fullWidth
                  required
                  inputProps={{
                    pattern: '^[A-Za-z]{4}-[0-9]{4}-[A-Za-z]{1}[0-9]{1}$'
                  }}
                />
              </Paper>
            </Grid>

            <Grid item xs={6}>
              <Paper style={{ padding: 16 }}>
                <TextField
                  label={t('length')}
                  name="length"
                  type="number"
                  value={formData.length > 0 ? formData.length : ''}
                  onChange={handleChange}
                  margin="normal"
                  fullWidth
                  required
                />
              </Paper>
            </Grid>

            <Grid item xs={6}>
              <Paper style={{ padding: 16 }}>
                <TextField
                  label={t('width')}
                  name="width"
                  type="number"
                  value={formData.width > 0 ? formData.width : ''}
                  onChange={handleChange}
                  margin="normal"
                  fullWidth
                  required
                />
              </Paper>
            </Grid>
          </Grid>
        </>

        <Wrapper>
          <DivRight>
            <Button
              type="button"
              variant="contained"
              color="primary"
              startIcon={<ArrowBackIcon />}
              href='/'
            >
              {t('backButton')}
            </Button>
            <Button
              type="submit"
              variant="contained"
              style={{
                color: '#fff',
                backgroundColor: '#079659',
                margin: '2px'
              }}
              startIcon={<SaveIcon />}
            >
              {t('saveButton')}
            </Button>
          </DivRight>
        </Wrapper>
      </form>
  );
};

export default EntryForm;