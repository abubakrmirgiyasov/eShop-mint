import React, { useCallback, useEffect, useState } from "react";
import { Button, Col, Modal, ModalBody, ModalHeader, Row } from "reactstrap";
import SubCategoryTable from "../../components/Tables/SubCategoryTable";
import SubCategoryAction from "./SubCategoryAction";
import { fetchWrapper } from "../../../helpers/fetchWrapper";
import { Error } from "../../../components/Notification/Error";
import DeleteSubCategory from "./DeleteSubCategory";

const SubCategories = ({ isOpen, toggle }) => {
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const [subCategories, setSubCategories] = useState(null);
  const [isEdit, setIsEdit] = useState(false);
  const [isDelete, setIsDelete] = useState(false);
  const [updateData, setUpdateData] = useState(null);
  const [deleteId, setDeleteId] = useState(false);

  useEffect(() => {
    setIsLoading(true);

    fetchWrapper
      .get("api/subcategory/getsubcategories")
      .then((response) => {
        setIsLoading(false);
        setSubCategories(response);
      })
      .catch((error) => {
        setError(error);
        setIsLoading(false);
      });
  }, []);

  const actionToggle = useCallback(() => {
    if (isEdit) {
      setIsEdit(false);
      setUpdateData(null);
    } else {
      setIsEdit(true);
    }
  }, [isEdit]);

  const deleteToggle = useCallback(() => {
    if (isDelete) {
      setIsDelete(false);
    } else {
      setIsDelete(true);
    }
  }, [isDelete]);

  function handleNewData(newItem) {
    setSubCategories([...subCategories, newItem]);
  }

  function handleUpdateData(item) {
    let data = [...subCategories];
    const temp = data.findIndex((x) => x.id === item.id);
    let subCategory = { ...data[temp] };
    subCategory.displayOrder = item.displayOrder;
    subCategory.name = item.name;
    subCategory.ico = item.ico;
    data[temp] = subCategory;
    setSubCategories(data);
  }

  function handleRemovedData(id) {
    const data = subCategories.filter((x) => x.id !== id);
    setSubCategories(data);
  }

  const handleUpdateClick = useCallback(
    (arg) => {
      setUpdateData(arg);
      setIsEdit(true);
      actionToggle();
    },
    [actionToggle]
  );

  const handleDeleteClick = useCallback(
    (arg) => {
      setDeleteId({ id: arg.id });
      setIsDelete(true);
      deleteToggle();
    },
    [deleteToggle]
  );

  return (
    <React.Fragment>
      {error ? <Error message={error} /> : null}
      <Modal
        isOpen={isOpen}
        toggle={toggle}
        className={"border-0"}
        modalClassName={"modal-xl fade zoomIn"}
        centered={true}
      >
        <ModalHeader
          className={"p-3 bg-soft-white border-bottom-dashed"}
          toggle={toggle}
          style={{ borderBottom: "1px" }}
        >
          Таблица под категорий
        </ModalHeader>
        <ModalBody>
          <Row>
            <Col
              lg={12}
              className={"d-flex justify-content-end align-items-center mb-3"}
            >
              <Button type={"button"} color={"danger"} onClick={actionToggle}>
                <i className={"ri ri-add-line me-2 fs-14"}></i>
                Добавить
              </Button>
            </Col>
            <Col lg={12}>
              {isLoading ? (
                <div
                  className={"d-flex justify-content-center align-items-center"}
                >
                  <div className={"spinner-grow text-success"} role={"status"}>
                    <span className={"visually-hidden"}>Loading...</span>
                  </div>
                </div>
              ) : (
                <SubCategoryTable
                  data={subCategories}
                  handleDeleteClick={handleDeleteClick}
                  handleUpdateClick={handleUpdateClick}
                />
              )}
            </Col>
          </Row>
        </ModalBody>
      </Modal>
      <SubCategoryAction
        isOpen={isEdit}
        toggle={actionToggle}
        newData={handleNewData}
        updateData={updateData}
        handleUpdateData={handleUpdateData}
      />
      <DeleteSubCategory
        isDelete={isDelete}
        toggle={deleteToggle}
        id={deleteId}
        removedData={handleRemovedData}
      />
    </React.Fragment>
  );
};

export default SubCategories;
