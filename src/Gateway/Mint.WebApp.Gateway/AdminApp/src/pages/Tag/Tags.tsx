import React, {FC, ReactNode, useCallback, useEffect, useState} from "react";
import {
  Button,
  ButtonGroup,
  Card,
  CardBody,
  CardHeader,
  Col,
  Collapse,
  DropdownItem,
  DropdownMenu,
  DropdownToggle,
  Row,
  UncontrolledDropdown,
} from "reactstrap";
import PrivateComponent from "../../services/CheckComponentRoles";
import {useDispatch, useSelector} from "react-redux";
import TagDelete from "./TagDelete";
import {ITag} from "../../types/Tags/ITag";
import Loader from "../../components/Common/Loader";
import {Colors} from "../../constants/commonList";
import {TagDataTable} from "../../components/Tables/TagDataTable";
import TagTableColumnController from "../../components/TableColumnController/TagTableColumnController";
import TagAction from "./TagAction";
import {useAxios} from "../../hooks/useAxios";
import {getTagsStore} from "../../stores/Tag/tagActions";
import {Roles} from "../../constants/roles";

const Tags: FC<ReactNode> = () => {
  document.title = "Атрибуты - Mint";

  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [isFilterOpen, setIsFilterOpen] = useState<boolean>(false);
  const [isSettingsOpen, setIsSettingsOpen] = useState<boolean>(false);
  const [isActionModal, setIsActionModal] = useState<boolean>(false);
  const [isDeleteModal, setIsDeleteModal] = useState<boolean>(false);
  const [isEdit, setIsEdit] = useState<boolean>(false);
  const [id, setId] = useState<string>("");
  const [singleTag, setSingleTag] = useState<ITag | null>(null);
  const [isShownTranslateColumn, setIsShownTranslateColumn] = useState<boolean>(true);

  const dispatch = useDispatch();
  const axios = useAxios();

  const { tags } = useSelector((state) => ({
   tags: state.Tags.data,
  }));

  useEffect(() => {
    setIsLoading(true);
    dispatch(getTagsStore(axios))
      .then(() => setIsLoading(false))
      .catch(() => setIsLoading(false));
  }, [dispatch]);

  const handleFilterClick = () => setIsFilterOpen(!isFilterOpen);

  const onDropDownButtonSettingsToggle = () => setIsSettingsOpen(!isSettingsOpen);

  const onAddNewClick = () => {
    setIsEdit(false);
    actionModalToggle();
  };

  const handleDeleteClick = (id: string) => {
    setId(id);
    deleteModalToggle();
  };

  const handleChangeClick = (tag: ITag) => {
    setSingleTag(tag);
    setIsEdit(true);
    actionModalToggle();
  };

  const handleTableControllerClick = (omit: boolean) => {
    setIsShownTranslateColumn(omit);
  };

  const actionModalToggle = useCallback(() => {
    if (isActionModal) {
      setIsActionModal(false);
      setSingleTag(null);
    } else {
      setIsActionModal(true);
    }
  }, [isActionModal]);


  const deleteModalToggle = useCallback(() => {
    if (isDeleteModal) {
      setIsDeleteModal(false);
      setId("");
    } else {
      setIsDeleteModal(true);
    }
  }, [isDeleteModal]);

  return (
    <div className={"page-content"}>
      <Card>
        <CardHeader>
          <h2 className={"mb-0"}>Атрибуты</h2>
        </CardHeader>
        <CardBody>
          {isLoading ? (
              <Loader isCenter={true} color={Colors.success} />
          ) : (
            <Row className={"gap-3"}>
              <Col lg={12}>
                <div className={"d-flex align-items-center"}>
                  <ButtonGroup className={"me-2"}>
                    <UncontrolledDropdown>
                      <DropdownToggle
                        tag={"button"}
                        className={`btn btn-outline-success ${isSettingsOpen ? "active" : ""}`}
                        onClick={onDropDownButtonSettingsToggle}
                      >
                        <i className={"ri-settings-4-line"}></i>
                      </DropdownToggle>
                      <DropdownMenu className={"dropdown-menu-md p-2"}>
                        <DropdownItem header>Вкл/Выкл столбец</DropdownItem>
                        <TagTableColumnController
                            isShownTranslateColumn={isShownTranslateColumn}
                            onSwitchColumn={handleTableControllerClick}
                        />
                      </DropdownMenu>
                    </UncontrolledDropdown>
                  </ButtonGroup>
                  <button
                    className={`me-2 fs-14 btn btn-outline-success ${isFilterOpen ? "active" : ""}`}
                    onClick={handleFilterClick}
                  >
                    <i className={"ri-filter-2-line"}></i>
                  </button>
                  {/*<PrivateComponent>*/}
                    <Button
                      onClick={onAddNewClick}
                      className={"fs-14 btn btn-success"}
                      roles={[Roles.Admin]}
                    >
                      <i className={"ri-add-line align-middle me-2"}></i>
                      Добавить новое...
                    </Button>
                  {/*</PrivateComponent>*/}
                </div>
                <Collapse isOpen={isFilterOpen} horizontal={false}>
                  <div className={"d-flex mt-3"}>
                    <input
                      type={"text"}
                      className={"w-25 me-2 form-control"}
                      placeholder={"Поиск по названию"}
                    />
                    <button className={"btn btn-outline-danger"}>
                      <i className={"ri-search-2-line"}></i>
                    </button>
                  </div>
                </Collapse>
              </Col>
              <Col lg={12}>
                <TagDataTable
                    data={tags}
                    omit={isShownTranslateColumn}
                    onChangeItem={handleChangeClick}
                    onRemoveItem={handleDeleteClick}
                />
              </Col>
            </Row>
          )}
        </CardBody>
      </Card>
      <TagAction
        isEdit={isEdit}
        isOpen={isActionModal}
        toggle={actionModalToggle}
        tag={singleTag}
      />
      <TagDelete
          id={id}
          isOpen={isDeleteModal}
          toggle={deleteModalToggle}
      />
    </div>
  );
};

export default Tags;
