import React from "react";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import Typography from "@material-ui/core/Typography";
import Button from "@material-ui/core/Button";
import SettingsIcon from "@material-ui/icons/Settings";
import { Avatar, IconButton, CardMedia } from "@material-ui/core";
import "./CSS/PromotionCard.css";
import { CloseButton } from "./CloseButton";
import * as bikeService from '../Services/BikeService.js';
import * as partService from '../Services/PartService.js';
import * as accessoryService from '../Services/AccessoryService.js';
import { useEffect, useState } from "react";
import DeleteIcon from "@material-ui/icons/Delete";
import * as promotionService from '../Services/PromotionService';

// import { Settings } from "@material-ui/icons"; 



function getUniquePropertyValues(_array, _property) {
    return _array.reduce((arr1, arr2) => {
        if (!arr1.includes(arr2[_property])) {
            arr1.push(arr2[_property]);
        }
        return arr1;
    }, []);
}

const PromotionCard = ({props,handleClick, keyUnique,role,id,image}) => {
    const { name, items } = props;
    var popupViews = document.querySelectorAll('.popup-view');
    var popupBtns = document.querySelectorAll('.popup-btn');
    var closeBtns = document.querySelectorAll('.close-btn');
    var addBtns = document.querySelectorAll('.add-cart-btn');

    const [token, setToken] = useState("");
    useEffect(() => {
        setToken(usr => localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).token : "user");
      }, [localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")).username : "user"]
      );



    // console.log("ID:",id);


    //javascript for quick view button
    var popup = function (popupClick) {
        popupViews[popupClick].classList.add('active');
    }

    

    let products = [];
    let discounts = [];
    let slideshow = [];
    let categories = [];
    let descrp = [];

    items.map((values) => {
        products.push(values.productId);
        categories.push(values.productCategory)
        // console.log("Category: ",values.productCategory);
        discounts.push(values.discount);
    });

    let obj1 = {
        name : props.name,
        items : props.items,
        price : 0,
        image : image 
    }

    const [images, setImages] = useState([]);
    const [description, setDescription] = useState([]);
    const [price, setPrice] = useState(0.0);
    const [obj,setObj] = useState(obj1);

    

    // console.log(obj);


    const imageProducts = async () => {
        var total=0.0;
        for (let i = 0; i < products.length; i++) {

            let response;
            if (categories[i] <= 3) {
                response = await bikeService.GetBikeById(products[i]);
            }
            else if (categories[i] == 4) {
                response = await partService.GetPartById(products[i]);
            }
            else if (categories[i] == 5) {
                response = await accessoryService.GetAccessoryById(products[i]);
            }

            slideshow.push(response.images[0].path);
            let obj = {
                manufacturer: response.manufacturer, 
                model: response.model,
                year: response.year,
                PRP: response.price,
                discount: discounts[i]
            }
            var pr = response.price - discounts[i] * response.price / 100;
            total= total+pr;
            if (!descrp.includes(obj)) {
                descrp.push(obj);
            }

            
        }
        setPrice(price + total);
        products = [];
        obj1.price = total;
        // console.log("PRICE TOTAL:", obj1.priceT);
        setObj(obj1);
        setImages(slideshow);
        setDescription(descrp);
    }
    useEffect(() => {
        imageProducts();
    }, []);

    let slideIndex = 1;
    let ok = 0;

    popupBtns.forEach((popupBtn, i) => {
        popupBtn.addEventListener("click", () => {
            popup(i);
            currentSlide(1);
        });
    });
    //javascript for close button
    closeBtns.forEach((closeBtn) => {
        closeBtn.addEventListener("click", () => {
            popupViews.forEach((popupView) => {
                popupView.classList.remove('active');
                slideIndex = 1;
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


    showSlides(slideIndex);


    // Next/previous controls
    function plusSlides(n) {
        showSlides(slideIndex += n);
    }

    // Thumbnail image controls
    function currentSlide(n) {
        showSlides(slideIndex = n);
    }


    // console.log(images);

    function showSlides(n) {
        
        if (ok == 1) {
            // console.log("aiici2");

            let i;
            let slides = document.getElementsByClassName(id);
            // console.log("SLIDES: ", slides);
            if (n > slides.length) {
                slideIndex = 1;
                // console.log("aiici3");

            }
            if (n < 1) {
                slideIndex = slides.length;
                // console.log("aiici4");

            }
            for (i = 0; i < slides.length; i++) {
                // slides[i].style.display = "none";
                slides[i].setAttribute("style", "display:none;")
            }

            //   slides[slideIndex-1].style.display = "block";

            slides[slideIndex - 1].setAttribute("style", "display:block;")
        }
    }

    ok = 1; 


    var uniq = getUniquePropertyValues(description, "model");
    // console.log("UNIQ:" , uniq);

    const uniqueDescription = description.filter((value, index) => {
        const _value = JSON.stringify(value);
        return index === description.findIndex(obj => {
          return JSON.stringify(obj) === _value;
        });
      });

    const uniqueImages =  images.filter((value, index) => {
        const _value = JSON.stringify(value);
        return index === images.findIndex(obj => {
          return JSON.stringify(obj) === _value;
        });
      });


      const deletePromotion = async () => {
     
          try {
            var result = await promotionService.DeletePromotion(id, token);
          }
          catch (err) {
            console.log("Something went wrong", err);
            alert("Something went wrong!");
          }
          if (result >= 200 && result < 210) {
            alert("Product deleted with success!")
            window.location.reload(false);
          }
    
          else alert("Something went wrong!");
        
      
      }
            // console.log("Description: ",unique);
           
    return (
        <div key={keyUnique}>
            <Card>
                <CardHeader
                    avatar={<Avatar src={images[0]} />}
                    action={
                        role === "Administrator" ? (
                            <IconButton aria-label="settings" onClick={deletePromotion} style={{ background: 'rgba(151, 126, 11, 0.205)' }}>
                            <DeleteIcon id="delete" />
                          </IconButton>
                        ) : (<div></div>)
                    }
                    title={name}
                />
                <CardMedia style={{ height: "200px", width: "350px" }} image={image} />
                <CardContent>
                    <Typography variant="body2" component="p">

                    </Typography>
                </CardContent>
                <CardActions>
                    <Button className="popup-btn" style={{ background: '#ffb84d' }}>Details</Button>
                </CardActions>
            </Card>
            <div className="product">
                <div className="popup-view">
                    <div className="popup-card">
                        <CloseButton />
                        <div className="product-img">
                            {
                                uniqueImages.map(function (each) {
                                    return (
                                        <div className={id} key={keyUnique + 2 + Math.random()}>
                                            <div className="mySlides fade" >
                                                <img src={each} alt="" style={{ height: "500px", width: "450px" }} />
                                            </div>
                                        </div>
                                    )
                                })


                            }
                           

                        </div>
                        <Button className="prev" onClick={() => plusSlides(-1)}>❮</Button>
                            <Button className="next" onClick={() => plusSlides(1)}>❯</Button>
                        <div className="info" style={{ height: "750px", width: "500px" }} >
                            <h3>Produse:<br /></h3>
                            {
                                uniqueDescription.map(function (each) {
                                    return (
                                        <div key={keyUnique + 3 + Math.random()}>
                                            <p>Producer: {each.manufacturer}</p>
                                            <p>Model: {each.model}</p>
                                            <p>Year: {each.year}</p>
                                            <p>PRP: {each.PRP} lei ( discount : {each.discount} %)</p>
                                        </div>
                                    )
                                })


                            }
                            <h2><br /><span></span></h2>

                            <span className="price">Pret {price} lei</span>

                            <button name="add_to_cart" className="add-cart-btn"  onClick={() => handleClick(obj)}>{role === "Administrator" ? "Select" : "Add to cart"}</button> 
                        </div>
                    </div>

                </div>
            </div>

        </div >


    );
};

export default PromotionCard;