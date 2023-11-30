import CancelIcon from '@material-ui/icons/Cancel';
import DeleteIcon from '@material-ui/icons/Delete';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import { useEffect, useState } from 'react';
import { useTranslation } from 'react-i18next';

interface ConfirmationProps {
  currentStatus: boolean;
  handleConfirm: Function;
}

const DeleteConfirmationDialog = ({ currentStatus, handleConfirm }: ConfirmationProps) => {
  const [open, setOpen] = useState(currentStatus);
  const { t } = useTranslation();

  useEffect(() => {
    setOpen(currentStatus);
  }, [currentStatus]);

  const handleClose = () => {
    setOpen(false);
  };
 
  return (
    <div>
      <Dialog open={open} onClose={handleClose}>
        <DialogTitle>{t('deleteConfirmationTitle')}</DialogTitle>
        <DialogContent>
          <DialogContentText>
          {t('deleteConfirmationMessage')}
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button
            startIcon={<CancelIcon />}
            color="primary"
            onClick={handleClose}
          >
            {t('cancelButton')}
          </Button>
          <Button
            startIcon={<DeleteIcon />}
            onClick={(id) => handleConfirm(id)} color="error"
          >
           {t('confirmButton')}
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default DeleteConfirmationDialog;