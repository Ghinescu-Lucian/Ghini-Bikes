import React, { useEffect, useState } from "react"
import { makeStyles } from "@material-ui/core/styles";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import Typography from "@material-ui/core/Typography";
import Button from "@material-ui/core/Button";
import DeleteIcon from "@material-ui/icons/Delete";
import SettingsIcon from "@material-ui/icons/Settings";
import { Avatar, IconButton, CardMedia } from "@material-ui/core";
import "./CSS/ProductCard.css";
import { CloseButton } from "./CloseButton";
import * as bikeService from '../Services/BikeService.js';
import { UpdateBikeForm } from "./UpdateBikeForm";

//  
const ProductCard = ({props,handleClick,image,role,id,data}) => {
  const { manufacturer, model, description, price} = props;
  const [token, setToken] = useState("");
  useEffect(() => {
    setToken(usr => localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).token : "user");
  }, [localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).username : "user"]
  );

  var popupViews = document.querySelectorAll('.popup-view');
  var popupBtns = document.querySelectorAll('.popup-btn');
  var closeBtns = document.querySelectorAll('.close-btn');
  var addBtns = document.querySelectorAll('.add-cart-btn');

  //javascript for quick view button
  var popup = function (popupClick) {
    popupViews[popupClick].classList.add('active');
  }

  popupBtns.forEach((popupBtn, i) => {
    popupBtn.addEventListener("click", () => {
      popup(i);
    });
  });
  //javascript for close button
  closeBtns.forEach((closeBtn) => {
    closeBtn.addEventListener("click", () => {
      popupViews.forEach((popupView) => {
        popupView.classList.remove('active');
      });
    });
  });

  addBtns.forEach((addBtn) => {
    addBtn.addEventListener("click", () => {
      popupViews.forEach((popupView) => {
        popupView.classList.remove('active');
      });
    });
  });

  const deleteProduct = async () => {

    try {
      var AddBike_Result = await bikeService.DeleteBike(id, token);
    }
    catch (err) {
      console.log("Something went wrong", err);
      alert("Something went wrong!");
    }
    if (AddBike_Result >= 200 && AddBike_Result < 210) {
      alert("Product deleted with success!")
      window.location.reload(false);
    }

    else alert("Something went wrong!");
  }

  // const handleClick = (item) => {
  //   console.log(item);  
  // };
  // console.log('ID:card:', id);
  return (
    <div className="product-card">
      <Card>
        <CardHeader
          avatar={<Avatar src={image} />}
          action={
            role === 'Administrator' ?
              (
              <IconButton aria-label="settings" onClick={deleteProduct}>
                <DeleteIcon id="delete" />
              </IconButton>
              ) : (<div></div>)

          }

          title={manufacturer}
          subheader={model}
        />

        <CardMedia style={{ height: "200px", width: "350px" }} image={image} />
        <CardContent>
          <Typography variant="body2" component="p">
            {description}
          </Typography>
        </CardContent>
        <CardActions>
          {/* <Button size="small">BUY NOW</Button> */}
          {/* <Button size="small">OFFER</Button> */}
          <Button className="popup-btn">Detalii</Button>
        </CardActions>
      </Card>
      <div className="product-card">
        <div className="product">
          <div className="popup-view">
            <div className="popup-card">
              <CloseButton />
              <div className="product-img">
                <img style={{ height: "500px", width: "500px" }} src={image} />
              </div>
              <div className="info" style={{ height: "500px", width: "500px" }} >
                <h2>{manufacturer}<br /><span>{model}</span></h2>
                <p>{description}</p>
                <p>{price} RON</p>
                  <button name="add_to_cart" className="add-cart-btn"  onClick={() => handleClick(props)}>{role === "Administrator" ? "Select" : "Add to cart"}</button> 
                {/* </form> */}
                {
                  role === 'Administrator' ? (
                    <div>
                      <Button className="popup-btn">Edit</Button>
                      {/* <div class="product-card"> */}
                      <div className="product">
                        <div className="popup-view">
                          <div className="popup-card"> 
                            <UpdateBikeForm data={data} />

                          </div>
                        </div>
                      </div>
                    </div>
                    ) : (<div></div>)
                }
              </div>
            </div>

          </div>
        </div>
      </div >
    </div >

  );
};

export default ProductCard;