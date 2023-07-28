import React, { FC, useState } from "react";
import { IUserAddress } from "../../services/types/IUser";
import { Modal, ModalBody, ModalHeader } from "reactstrap";
import { Error } from "../../components/Notifications/Error";

interface IAddressAction {
  userId: string;
  address: IUserAddress;
  isEdit: boolean;
  isOpen: boolean;
  toggle: () => void;
  handleNewAddress: (address: IUserAddress) => void;
  handleUpdateAddress: (address: IUserAddress) => void;
}

const AddressesAction: FC<IAddressAction> = (props) => {
  const {
    userId,
    address,
    isEdit,
    isOpen,
    toggle,
    handleUpdateAddress,
    handleNewAddress,
  } = props;

  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>("");

  return (
    <React.Fragment>
      {error && <Error message={error} />}
      <Modal
        isOpen={isOpen}
        toggle={toggle}
        className={"border-0"}
        modalClasName={"modal-xxl fade zoomIn"}
      >
        <ModalHeader
          className={"p-3 bg-soft-white border-bottom-dashed"}
          toggle={toggle}
          style={{ borderBottom: "1px" }}
        >
          {!isEdit ? "Изменить адрес" : "Добавить адрес"}
        </ModalHeader>
        <ModalBody className={"modal-body"}>
          <form></form>
        </ModalBody>
      </Modal>
    </React.Fragment>
  );
};

export default AddressesAction;
