import { useEffect, useState } from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogTitle from '@mui/material/DialogTitle';
import DialogActions from '@mui/material/DialogActions';

interface ConfirmationProps {
  currentStatus: boolean;
  message: string;
}

const ErrorDialog = ({ currentStatus, message }: ConfirmationProps) => {
  const [open, setOpen] = useState(currentStatus);

  useEffect(() => {
    setOpen(currentStatus);
  }, [currentStatus]);

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <div>
      <Dialog open={open} onClose={handleClose}>
        <DialogTitle>{message}</DialogTitle>
        <DialogActions>
          <Button
            color="primary"
            onClick={handleClose}
          >
            Ok
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default ErrorDialog;