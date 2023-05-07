import React, { useEffect, useState } from "react";
import {
  Accordion,
  AccordionItem,
  Card,
  CardBody,
  Col,
  Collapse,
  Container,
  Form,
  Input,
  Row,
} from "reactstrap";
import Breadcrumb from "../../components/Breadcrumb/Breadcrumb";
import { useSelector } from "react-redux";
import { Link, useNavigate, useParams } from "react-router-dom";
import classnames from "classnames";

const SingleCategory = () => {
  const [title, setTitle] = useState(null);

  const params = useParams();
  const navigate = useNavigate();

  const { menu } = useSelector((state) => ({
    menu: state.Categories.menu,
  }));

  useEffect(() => {
    if (params.name) {
      menu.map((item) =>
        item.menuChildViewModels.map((child) => {
          if (child.link === params.name) {
            setTitle(child.childName);
            return;
          }
        })
      );
    } else {
      navigate("/categories");
    }
  }, [params]);

  console.log(title);

  const [fillCol1, setfillCol1] = useState(true);
  const [fillCol2, setfillCol2] = useState(false);
  const [fillCol3, setfillCol3] = useState(false);

  const t_fillCol1 = () => {
    setfillCol1(!fillCol1);
    setfillCol2(false);
    setfillCol3(false);
  };

  const t_fillCol2 = () => {
    setfillCol2(!fillCol2);
    setfillCol1(false);
    setfillCol3(false);
  };

  const t_fillCol3 = () => {
    setfillCol3(!fillCol3);
    setfillCol1(false);
    setfillCol2(false);
  };

  return (
    <div className={"page-content"}>
      <Container fluid={true}>
        <Breadcrumb
          title={title}
          pageTitle={"Категории"}
          link={"/categories"}
        />
        <Row>
          <Col lg={3}>
            <Card>
              <CardBody>
                <div className={"app-search d-none d-md-block mt-0 mb-0 p-0"}>
                  <div className={"position-relative p-0"}>
                    <Input
                      type={"text"}
                      className={"form-control mt-0 mb-0"}
                      placeholder={"Поиск..."}
                      defaultValue={""}
                      // onChange={() => {}}
                    />
                    <span
                      className={"mdi mdi-magnify search-widget-icon"}
                    ></span>
                    <span
                      className={
                        "mdi mdi-close-circle search-widget-icon search-widget-icon-close d-none"
                      }
                      id={"search-close-options"}
                    ></span>
                  </div>
                </div>
              </CardBody>
            </Card>
          </Col>
          <Col lg={9}>
            <Card>
              <CardBody></CardBody>
            </Card>
          </Col>
          <Col lg={3}>
            <Card>
              <CardBody>
                <Accordion
                  className="custom-accordionwithicon accordion-fill-success"
                  id="accordionFill"
                >
                  <AccordionItem>
                    <h2 className="accordion-header" id="accordionFillExample1">
                      <button
                        className={classnames("accordion-button", {
                          collapsed: !fillCol1,
                        })}
                        type="button"
                        onClick={t_fillCol1}
                        style={{ cursor: "pointer" }}
                      >
                        What are webhooks?
                      </button>
                    </h2>
                    <Collapse
                      isOpen={fillCol1}
                      className="accordion-collapse"
                      id="accor_fill1"
                    >
                      <div className="accordion-body">
                        Webhooks allow you to gather real time data on key
                        interactions that happen with your Slick Text account.
                        Simply provide us with a url where you'd like the data
                        to be sent, choose which events you'd like to be
                        informed of, and click save.{" "}
                      </div>
                    </Collapse>
                  </AccordionItem>
                  <AccordionItem>
                    <h2 className="accordion-header" id="accordionFillExample2">
                      <button
                        className={classnames("accordion-button", {
                          collapsed: !fillCol2,
                        })}
                        type="button"
                        onClick={t_fillCol2}
                        style={{ cursor: "pointer" }}
                      >
                        Where can I find my Textword ID?
                      </button>
                    </h2>
                    <Collapse
                      isOpen={fillCol2}
                      className="accordion-collapse"
                      id="accor_fill2"
                    >
                      <div className="accordion-body">
                        Head over to the Textwords page. Click options on the
                        right hand side, and then click Settings. This will
                        redirect you to your Textword Setting page. Now, go
                        check your url, and the textword ID will be the number
                        after "word=". Too much or too little spacing, as in the
                        example below.
                      </div>
                    </Collapse>
                  </AccordionItem>
                  <AccordionItem>
                    <h2 className="accordion-header" id="accordionFillExample3">
                      <button
                        className={classnames("accordion-button", {
                          collapsed: !fillCol3,
                        })}
                        type="button"
                        onClick={t_fillCol3}
                        style={{ cursor: "pointer" }}
                      >
                        Производители
                      </button>
                    </h2>
                    <Collapse
                      isOpen={fillCol3}
                      className="accordion-collapse"
                      id="accor_fill3"
                    >
                      test1
                    </Collapse>
                  </AccordionItem>
                </Accordion>
              </CardBody>
            </Card>
          </Col>
          <Col lg={9}>
            <Card>
              <CardBody></CardBody>
            </Card>
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default SingleCategory;
